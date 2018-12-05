import { Component, OnInit } from '@angular/core';

import { Customer } from '../../models/Customer.Model';
import { CustomerService } from '../../services/customer.service';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  customers: Customer[];

  constructor(private customerService: CustomerService) { }

  deactivatCustomer(id) {
    this.customerService.softDeleteCustomer(id).subscribe(res => {
      console.log(res);
      console.log('deactivated');
    });
  }





  ngOnInit() {
    this.customerService
      .getAllCustomers()
      .subscribe((res: any) => {
        console.log(res);
        this.customers = res.data;
        console.log(this.customers);

      });
  }
}
