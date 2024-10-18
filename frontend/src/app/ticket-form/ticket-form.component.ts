import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { IBaseRepository } from '../core/interface/IBaseRepository';
import { TicketRepository } from '../core/repository/TicketRepository';
import { Ticket } from '../core/model/Ticket';
import { TicketDataDto } from '../core/model/dto/TicketDto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ticket-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './ticket-form.component.html',
  styleUrl: './ticket-form.component.css'
})
export class TicketFormComponent {

  TicketRepo: IBaseRepository<Ticket> = new TicketRepository();
  ticketForm: FormGroup;
  isEdit = false;
  ticketId = 0;

  get description() {
    return this.ticketForm.get('description');
  }

  get isOpened() {
    return this.ticketForm.get('isOpened');
  }

  constructor(private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute) {
    this.ticketForm = this.fb.group({
      description: ['', Validators.required],
      isOpened: [false]
    });
  }

  async saveTicket() {
    if (this.ticketForm.valid) {
      if(!this.isEdit) {
        const formData : TicketDataDto = this.ticketForm.value;
        formData.isOpened = !formData.isOpened;
        console.log('Form Data:', formData);
        await this.TicketRepo.add(formData);

        // Handle form submission, e.g., send data to a server
        this.router.navigate(['/tickets']);
      }
      else
      {
        const formData : TicketDataDto = this.ticketForm.value;
        formData.isOpened = !formData.isOpened;
        console.log('Form Data:', formData);
        await this.TicketRepo.update(this.ticketId, formData);

        // Handle form submission, e.g., send data to a server
        this.router.navigate(['/tickets']);
      }
    }
    else {
      console.log('Form is invalid');
    }
  }

   loadTicket(id: number): void {
    // Load ticket data from the server or service
    this.TicketRepo.getById(id).then(ticket => {
      ticket.isOpened = !ticket.isOpened;
      this.ticketForm.patchValue(ticket);
      this.isEdit = true;
    });
  }

  goBack() {
    window.history.back();
  }

  ngOnInit(): void {

    // Access route parameters
    this.route.paramMap.subscribe(params => {
      this.ticketId = parseInt(params.get('id') || '0');
      if (this.ticketId > 0) {
        // Load ticket data if editing
        this.loadTicket(this.ticketId);
      }
    });
  }
}
