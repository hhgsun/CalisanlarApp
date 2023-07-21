import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { API_URL } from 'src/constants';
import { AppPagination } from 'src/models/app-pagination.model';
import { AppResponse } from 'src/models/app-response.model';
import { Calisan } from 'src/models/calisan.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient) {
  }

  public getCalisan(id: number): Observable<AppResponse<Calisan>> {
    return this.http.get<AppResponse<Calisan>>(API_URL + "/calisanlar/" + id);
  }

  public getListCalisanlar(offset: number, limit: number): Observable<AppResponse<AppPagination<Calisan>>> {
    return this.http.get<AppResponse<AppPagination<Calisan>>>(API_URL + "/calisanlar", {
      params: { offset, limit }
    });
  }

  public addCalisan(data: Calisan): Observable<AppResponse<boolean>> {
    return this.http.post<AppResponse<boolean>>(API_URL + "/calisanlar", data);
  }

  public saveCalisan(data: Calisan): Observable<AppResponse<boolean>> {
    return this.http.put<AppResponse<boolean>>(API_URL + "/calisanlar", data);
  }

  public deleteCalisan(id: number): Observable<AppResponse<boolean>> {
    return this.http.delete<AppResponse<boolean>>(API_URL + "/calisanlar", {
      params: { id }
    });
  }

}
