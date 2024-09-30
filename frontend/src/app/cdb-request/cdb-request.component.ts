import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CDBCalculo } from '../model/cdb.model';
import { CalculoCDBService } from '../services/calculo-cdb.service';

@Component({
  selector: 'cdb-request',
  templateUrl: './cdb-request.component.html',
  styleUrl: './cdb-request.component.css'
})

export class CDBRequestComponent implements OnInit {
  
  cdbForm: FormGroup;
  cdbItems: CDBCalculo[] = []; 
  editingItemId: string | null = null;

  constructor(private fb: FormBuilder, private cdbService: CalculoCDBService) {
    this.cdbForm = this.fb.group({
      id: [null],
      valorInicial: [null, [Validators.required, Validators.min(0)]],
      cdi: [null, [Validators.required]],
      taxaBanco: [null, [Validators.required]],
      meses: [null, [Validators.required, Validators.min(1)]]
    });
  }

  ngOnInit() : void {
    this.loadCdbItems();
  }

  onSubmit(): void {
    debugger;
    if (this.cdbForm.valid) {
      const cdbCalculo: CDBCalculo = this.cdbForm.value;
  
      if (cdbCalculo.id) {
        // Modo de edição
        this.cdbService.update(cdbCalculo).subscribe({
          next: (result) => {
            console.log('CDB atualizado com sucesso:', result);
            const index = this.cdbItems.findIndex(item => item.id === result.id);
            if (index !== -1) {
              this.cdbItems[index] = result;
            }
            this.cdbForm.reset();
          },
          error: (error) => {
            console.error('Erro ao atualizar CDB:', error);
          }
        });
      } else {
        // Modo de adição
        this.cdbService.add(cdbCalculo).subscribe({
          next: (result) => {
            console.log('CDB calculado com sucesso:', result);
            this.cdbItems.push(result);
            this.cdbForm.reset();
          },
          error: (error) => {
            console.error('Erro ao calcular CDB:', error);
          }
        });
      }
    } else {
      console.log('Formulário inválido');
    }
  }
  

  loadCdbItems(): void {
    this.cdbService.getAll().subscribe({
      next: (items) => {
        this.cdbItems = items;
      },
      error: (error) => {
        console.error('Erro ao carregar itens:', error);
      }
    });
  }

  editItem(item: CDBCalculo): void {
    this.cdbForm.patchValue(item);
    this.editingItemId = item.id;
  }

  deleteItem(id: string): void {
    if (confirm('Tem certeza que deseja excluir este item?')) {
      this.cdbService.delete(id).subscribe({
        next: () => {
          console.log('CDB excluído com sucesso.');
          this.loadCdbItems();
        },
        error: (error) => {
          console.error('Erro ao excluir CDB:', error);
        }
      });
    }
  }
}
