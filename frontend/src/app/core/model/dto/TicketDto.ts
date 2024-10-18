import { Ticket } from '../Ticket';

export interface GetTicketPageDto {
  tickets?: Ticket[];
  currentPage: number;
  totalPage: number;
}

export interface TicketDataDto {
  description: string;
  isOpened?: boolean;
}
