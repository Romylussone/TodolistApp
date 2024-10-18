import { Routes } from '@angular/router';
import { TicketListComponent } from './ticket-list/ticket-list.component';
import { TicketFormComponent } from './ticket-form/ticket-form.component';

export const routes: Routes = [
  { path: 'tickets', component: TicketListComponent },
  { path: 'ticket/add', component: TicketFormComponent },
  { path: 'ticket/edit/:id', component: TicketFormComponent },
  { path: '', component: TicketListComponent },
];
