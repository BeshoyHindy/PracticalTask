import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CustomerService } from '../../services/customer.service';
import { Customer } from '../../models/Customer.Model';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  angForm: FormGroup;
  customerModel: Customer;

  constructor(private customerService: CustomerService, private fb: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.angForm = this.fb.group({
      unit_name: ['', Validators.required],
      unit_price: ['', Validators.required]
    });
  }

  addNewCustomer() {
    this.customerModel.IsActive = true;
    this.customerModel.Name = "test name";


    this.customerService.createCustomer(this.customerModel);
  }
  ngOnInit() {
  }

}
