import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CDBCalculo, CDBResult } from '../model/cdb.model';

@Injectable({
  providedIn: 'root'
})
export class CalculoCDBService {
  private apiUrl = 'https://localhost:44320/api/calculoCdb';

  constructor(private http: HttpClient) { }

  getAll(): Observable<CDBResult[]> {
    return this.http.get<CDBResult[]>(this.apiUrl);
  }

  getById(id: string): Observable<CDBResult> {
    return this.http.get<CDBResult>(`${this.apiUrl}/${id}`);
  }

  add(calculoCDB: CDBCalculo): Observable<CDBResult> {
    debugger;
    return this.http.post<CDBResult>(this.apiUrl, calculoCDB);
  }

  update(calculoCDB: CDBCalculo): Observable<CDBResult> {
    return this.http.put<CDBResult>(this.apiUrl, calculoCDB);
  }

  delete(id: string): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`);
  }
}
