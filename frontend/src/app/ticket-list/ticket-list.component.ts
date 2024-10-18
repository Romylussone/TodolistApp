import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { IBaseRepository } from '../core/interface/IBaseRepository';
import { TicketRepository } from '../core/repository/TicketRepository';
import { Ticket } from '../core/model/Ticket';
import { IPaginateRepository } from '../core/interface/IPaginateRepository';
import { GetTicketPageDto, TicketDataDto } from '../core/model/dto/TicketDto';

@Component({
  selector: 'app-ticket-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './ticket-list.component.html',
  styleUrl: './ticket-list.component.css'
})
export class TicketListComponent {

  TicketRepo: IBaseRepository<Ticket>  = new TicketRepository();
  TicketPaginateRepo: IPaginateRepository  = new TicketRepository();
  defaultPageSize = 5;
  currentPage = 1;
  totalPages = 0;
  totalPagesArray :number[] = [];
  rows?: Ticket[] = [];

  constructor() {
    this.getTicketPageData(1);
  }

  getTicketPageData(page: number) {
    this.currentPage = page;
    this.TicketPaginateRepo.getTicketPage(page, this.defaultPageSize).then( data => {
      console.log(data)
      let elems = data as GetTicketPageDto;
      this.rows = elems.tickets;
      this.totalPages = elems.totalPage;
      this.totalPagesArray = Array.from({length: this.totalPages}, (v, k) => k+1);
    })
  }

  changePage(page: number) {
    this.getTicketPageData(page);
  }

  deleteTicket(id: number) {
    this.TicketRepo.delete(id);
    this.getTicketPageData(this.currentPage);
  }

  ngOnInit(): void {
  }
}
