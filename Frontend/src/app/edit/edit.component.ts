import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { StatusType } from 'src/constants';
import { CalisanKonum } from 'src/models/calisan-konum.model';
import { Calisan } from 'src/models/calisan.model';
import { ApiService } from 'src/services/api.service';

export class Hero {
  constructor(
    public id: number,
    public name: string,
    public power: string,
    public alterEgo?: string
  ) { }
}


@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.less']
})
export class EditComponent {
  activeTabIndex = 0;
  tabs = [
    {
      id: "profile",
      label: "Kişisel Bilgiler"
    },
    {
      id: "address",
      label: "Adres Bilgileri"
    }
  ]

  profileForm = new FormGroup({
    ad: new FormControl('', [Validators.required]),
    soyad: new FormControl('', [Validators.required]),
    yas: new FormControl('', [Validators.required]),
    cinsiyet: new FormControl(''),
    eposta: new FormControl('', [Validators.required, Validators.email]),
    telefon: new FormControl(''),
    adres: new FormControl('', [Validators.required,]),
    adres2: new FormControl(''),
    ilce: new FormControl('', [Validators.required]),
    sehir: new FormControl('', [Validators.required]),
  });

  isEditPage = false;
  editCalisanId: number = -1;

  constructor(private apiService: ApiService, private router: Router, private activatedRoute: ActivatedRoute) {
  }

  ngOnInit() {
    const editCalisanId = this.activatedRoute.snapshot.paramMap.get('id');
    if (editCalisanId) {
      this.isEditPage = true;
      this.editCalisanId = Number(editCalisanId)
      this.getCalisan();
    }
  }

  onSubmit() {
    if (!this.profileForm.valid)
      return;
    if (this.isEditPage && this.editCalisanId > 0)
      this.saveCalisan();
    else
      this.addCalisan();
  }

  setTabIndex(index: number) {
    this.activeTabIndex = index;
  }

  getFormValues(): Calisan {
    const formValue = this.profileForm.value;
    var calisan = new Calisan();
    calisan.ad = formValue.ad || '';
    calisan.soyad = formValue.soyad || '';
    calisan.cinsiyet = formValue.cinsiyet || '';
    calisan.ePosta = formValue.eposta || '';
    calisan.telefon = formValue.telefon || '';
    if (typeof formValue.yas === 'number') calisan.yas = formValue.yas;
    calisan.konum = new CalisanKonum();
    calisan.konum.adres = formValue.adres || '';
    calisan.konum.adres2 = formValue.adres2 || '';
    calisan.konum.ilce = formValue.ilce || '';
    calisan.konum.sehir = formValue.sehir || '';
    return calisan;
  }

  setFormValues(calisan?: Calisan) {
    this.profileForm.controls['ad'].setValue(calisan?.ad || "");
    this.profileForm.controls['soyad'].setValue(calisan?.soyad || "");
    this.profileForm.controls['cinsiyet'].setValue(calisan?.cinsiyet || "");
    this.profileForm.controls['eposta'].setValue(calisan?.ePosta || "");
    this.profileForm.controls['telefon'].setValue(calisan?.telefon || "");
    if (typeof calisan?.yas === 'number')
      this.profileForm.controls['yas'].setValue(calisan.yas.toString());
    this.profileForm.controls['adres'].setValue(calisan?.konum?.adres || "");
    this.profileForm.controls['adres2'].setValue(calisan?.konum?.adres2 || "");
    this.profileForm.controls['ilce'].setValue(calisan?.konum?.ilce || "");
    this.profileForm.controls['sehir'].setValue(calisan?.konum?.sehir || "");
  }

  addCalisan() {
    const calisan = this.getFormValues();
    this.apiService.addCalisan(calisan).subscribe(response => {
      if (response.status == StatusType.SUCCESS) {
        this.router.navigate(['list']);
      } else {
        alert(response.description);
      }
    }, err => {
      alert(err?.message)
    });
  }

  saveCalisan() {
    const calisan = this.getFormValues();
    calisan.id = this.editCalisanId;
    this.apiService.saveCalisan(calisan).subscribe(response => {
      alert(response.description);
    }, err => {
      alert(err?.message)
    });
  }

  getCalisan() {
    this.apiService.getCalisan(this.editCalisanId).subscribe(response => {
      if (response.status == StatusType.SUCCESS) {
        this.setFormValues(response.result as Calisan)
      } else {
        alert(response.description);
      }
    })
  }

  deleteCalisan() {
    if (!confirm("Silmek istediğinize emin misiniz?"))
      return;
    this.apiService.deleteCalisan(this.editCalisanId).subscribe(response => {
      alert(response.description);
      if (response.status == StatusType.SUCCESS) {
        this.router.navigate(['list']);
      }
    }, err => {
      alert(err?.message)
    });
  }

}
