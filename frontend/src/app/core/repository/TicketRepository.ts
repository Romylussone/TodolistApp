import { IBaseRepository } from "../interface/IBaseRepository";
import { TicketDataDto } from "../model/dto/TicketDto";
import { Ticket } from "../model/Ticket";

export class TicketRepository implements IBaseRepository<Ticket> {

  private _baseUrl = 'https://localhost:7280';

  constructor() {}

  getAll(): Promise<Ticket[]> {
    return fetch(`${this._baseUrl}/api/tickets`)
      .then(response => {
        console.log(response);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => data as Ticket[]);
  }

  getById(id: number): Promise<Ticket> {
    return fetch(`${this._baseUrl}/api/tickets/${id}`)
      .then(response => {
        console.log(response);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => data as Ticket);
  }

  add(entity: TicketDataDto): Promise<Ticket> {
    return fetch(`${this._baseUrl}/api/tickets`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(entity)
    })
      .then(response => {
        console.log(response);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => data as Ticket);
  }
  update(id: number, entity: TicketDataDto): Promise<boolean> {
    return fetch(`${this._baseUrl}/api/tickets/${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(entity)
    })
      .then(response => {
        console.log(response);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return true;
      })
      .then(data => data as boolean);
  }

  delete(id: number): Promise<boolean> {
    return fetch(`${this._baseUrl}/api/tickets/${id}`, {
      method: 'DELETE'
    })
      .then(response => {
        console.log(response);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return true;
      })
      .then(data => data as boolean);
  }

  getTicketPage(page: number, size: number): Promise<Ticket[]>
  {
    return fetch(`${this._baseUrl}/api/Tickets/page/${page}/limit/${size}`)
      .then(response => {
        console.log(response);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => data as Ticket[]);
  }
}
