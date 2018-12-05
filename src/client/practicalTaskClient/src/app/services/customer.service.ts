import { Injectable } from '@angular/core';  
import { HttpClient } from '@angular/common/http';  
import { Customer } from '../models/Customer.Model';
  
@Injectable({  
  providedIn: 'root'  
})  
export class CustomerService {  
  
  constructor(private http: HttpClient) { }  
  baseUrl: string = 'http://localhost:3004/api/';  
  
  getAllCustomers() {  
    return this.http.get<Customer[]>(this.baseUrl);  
  }  
  deleteCustomer(id: string) {  
    return this.http.delete<Customer[]>(this.baseUrl + id);  
  }  
  createCustomer(customer: Customer) {  
    return this.http.post(this.baseUrl, customer);  
  }  
  getCustomerById(id: string) {  
    return this.http.get<Customer>(this.baseUrl + '/' + id);  
  }  
  updateCustomer(customer: Customer) {  
    return this.http.put(this.baseUrl + '/' + customer.Id, customer);  
  }  
}  