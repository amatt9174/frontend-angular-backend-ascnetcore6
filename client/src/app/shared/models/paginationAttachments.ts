import { IAttachment } from './attachment';

export interface IPaginationAttachments
 {
  pagIndex: number;
  pageSize: number;
  count: number;
  data: IAttachment[];
}
