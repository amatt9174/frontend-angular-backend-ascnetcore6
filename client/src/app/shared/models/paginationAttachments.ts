import { IAttachment } from './attachment';

export interface IPaginationAttachments
 {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IAttachment[];
}
