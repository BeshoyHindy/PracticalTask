import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../models/Customer.Model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }
  baseUrl: string = 'https://localhost:44353/api/Customer';

  getAllCustomers() {
    return this.http.get<Customer[]>(this.baseUrl);
  }
  deleteCustomer(id: string) {
    return this.http.delete<Customer[]>(this.baseUrl + id);
  }
  softDeleteCustomer(id: string) {
    return this.http.put<any>(this.baseUrl + '/soft-delete/' + id, {});
  }
  createCustomer(customer: Customer) {
    debugger
    return this.http.post(this.baseUrl, customer);
  }
  getCustomerById(id: string) {
    return this.http.get<any>(this.baseUrl + '/' + id);
  }
  updateCustomer(customer: Customer) {
    return this.http.put(this.baseUrl, customer);
  }
}

