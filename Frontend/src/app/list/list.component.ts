import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StatusType } from 'src/constants';
import { Calisan } from 'src/models/calisan.model';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.less']
})
export class ListComponent {
  rows = new Array<Calisan>;
  columns = [
    { prop: 'id', name: 'ID' },
    { prop: 'ad', name: 'Ad' },
    { prop: 'soyad', name: 'Soyad' },
    { prop: 'yas', name: 'Yaş' },
    { prop: 'cinsiyet', name: 'Cinsiyet' },
    { prop: 'ePosta', name: 'EPosta' },
    { prop: 'telefon', name: 'Telefon' },
    { prop: 'konum.adres', name: 'Adres' },
    { prop: 'konum.adres2', name: 'Adres2' },
    { prop: 'konum.ilce', name: 'İlçe' },
    { prop: 'konum.sehir', name: 'Şehir' },
  ];
  loadingIndicator = true;
  page = {
    size: 10,
    totalElements: 0,
    totalPages: 0,
    pageNumber: 0
  }

  constructor(private apiService: ApiService, private router: Router) {
    this.loadCalisanlar();
  }

  ngOnInit() {
    this.loadCalisanlar();
  }

  public loadCalisanlar() {
    this.loadingIndicator = true;
    this.apiService.getListCalisanlar(this.page.pageNumber, this.page.size).subscribe(response => {
      this.loadingIndicator = false;
      if (StatusType.SUCCESS == response.status) {
        this.rows = response.result?.records || [];
        const total = response.result?.total || 0;
        this.page.totalElements = total;
        this.page.totalPages = total / this.page.size;
      }
    }, err => {
      alert(err?.message)
    })
  }

  changePage(pageInfo: any) {
    this.rows = [];
    this.page.pageNumber = (pageInfo.offset + 1);
    this.loadCalisanlar();
  }

  editItem(row: any) {
    this.router.navigate(['edit/' + row?.id]);
  }

}
