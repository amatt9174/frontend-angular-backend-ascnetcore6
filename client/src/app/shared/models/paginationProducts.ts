import { IProduct } from './product';

export interface IPaginationProducts
 {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IProduct[];
}
