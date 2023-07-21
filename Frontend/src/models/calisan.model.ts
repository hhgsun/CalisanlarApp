import { CalisanKonum } from "./calisan-konum.model";

export class Calisan {
  public id?: number;
  public ad?: string;
  public soyad?: string;
  public yas?: number;
  public cinsiyet?: string;
  public ePosta?: string;
  public telefon?: string;
  public konum?: CalisanKonum
}