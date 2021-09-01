import { IAttachment } from './attachment';

export interface IPagination
 {
  pagIndex: number;
  pageSize: number;
  count: number;
  data: IAttachment[];
}
