export interface IPaginateRepository {
  getTicketPage(page: number, size: number): Promise<unknown>
}
