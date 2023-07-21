export class AppResponse<T> {
  status: string = "";
  description: string = "";
  result?: T;

  constructor() {
  }
}