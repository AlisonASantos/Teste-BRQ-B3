import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { CDBRequestComponent } from './cdb-request.component';
import { CalculoCDBService } from '../services/calculo-cdb.service';
import { of, throwError } from 'rxjs';

describe('CDBRequestComponent', () => {
  let component: CDBRequestComponent;
  let fixture: ComponentFixture<CDBRequestComponent>;
  let mockCdbService: jasmine.SpyObj<CalculoCDBService>;

  beforeEach(async () => {
    mockCdbService = jasmine.createSpyObj('CalculoCDBService', ['getAll', 'add', 'update', 'delete']);

    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule],
      declarations: [CDBRequestComponent],
      providers: [{ provide: CalculoCDBService, useValue: mockCdbService }]
    }).compileComponents();

    fixture = TestBed.createComponent(CDBRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize the form', () => {
    expect(component.cdbForm).toBeDefined();
    expect(component.cdbForm.controls['valorInicial']).toBeDefined();
    expect(component.cdbForm.controls['cdi']).toBeDefined();
    expect(component.cdbForm.controls['taxaBanco']).toBeDefined();
    expect(component.cdbForm.controls['meses']).toBeDefined();
  });

  it('should load CDB items on initialization', () => {
    const mockItems = [{ id: 1, valorInicial: 1000, cdi: 5, taxaBanco: 1, meses: 12 }];
    mockCdbService.getAll.and.returnValue(of(mockItems));

    component.ngOnInit();

    expect(mockCdbService.getAll).toHaveBeenCalled();
    expect(component.cdbItems).toEqual(mockItems);
  });

  it('should submit form and add new item', () => {
    const mockItem = { id: null, valorInicial: 1000, cdi: 5, taxaBanco: 1, meses: 12 };
    component.cdbForm.setValue(mockItem);
    mockCdbService.add.and.returnValue(of({ ...mockItem, id: 1 }));

    component.onSubmit();

    expect(mockCdbService.add).toHaveBeenCalledWith(mockItem);
    expect(component.cdbItems.length).toBe(1);
    expect(component.cdbForm.value).toEqual({ id: null, valorInicial: null, cdi: null, taxaBanco: null, meses: null });
  });

  it('should submit form and update existing item', () => {
    const mockItem = { id: '1', valorInicial: 1000, cdi: 5, taxaBanco: 1, meses: 12 };
    component.cdbForm.setValue(mockItem);
    mockCdbService.update.and.returnValue(of(mockItem));
    component.cdbItems.push(mockItem);

    component.onSubmit();

    expect(mockCdbService.update).toHaveBeenCalledWith(mockItem);
    expect(component.cdbItems[0]).toEqual(mockItem);
  });

  it('should handle error when loading CDB items', () => {
    mockCdbService.getAll.and.returnValue(throwError('Error loading items'));

    component.loadCdbItems();

    expect(mockCdbService.getAll).toHaveBeenCalled();
    expect(component.cdbItems).toEqual([]);
  });

  it('should delete item', () => {
    const mockItem = { id: '1', valorInicial: 1000, cdi: 5, taxaBanco: 1, meses: 12 };
    component.cdbItems.push(mockItem);
    mockCdbService.delete.and.returnValue(of(null));

    spyOn(window, 'confirm').and.returnValue(true); // Mock confirm dialog

    component.deleteItem(mockItem.id);

    expect(mockCdbService.delete).toHaveBeenCalledWith(mockItem.id);
    expect(component.cdbItems.length).toBe(0);
  });
});
