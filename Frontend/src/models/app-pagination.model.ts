export class AppPagination<T> {
  limit: number = 0;
  pageNumber: number = 0;
  total: number = 0;
  records?: Array<T>;
  
  constructor() {
  }
}