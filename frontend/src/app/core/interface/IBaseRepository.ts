export interface IBaseRepository<T> {
  getAll(): Promise<T[]>;
  getById(id: number): Promise<T>;
  add(entity: unknown): Promise<T>;
  update(id: number, entity: unknown): Promise<boolean>;
  delete(id: number): Promise<boolean>;
}
