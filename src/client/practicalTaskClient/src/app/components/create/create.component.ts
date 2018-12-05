import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CustomerService } from '../../services/customer.service';
import { Customer } from '../../models/Customer.Model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  angForm: FormGroup;
  customerModel: Customer;

  constructor(private customerService: CustomerService, private router: Router, private fb: FormBuilder) {
    this.createForm();
    this.customerModel = new Customer;
  }

  createForm() {
    this.angForm = this.fb.group({
      unit_name: ['', Validators.required],
      unit_price: ['', Validators.required]
    });
  }

  onSubmit() {
   
    this.addNewCustomer();
  }

  addNewCustomer() {
    this.customerService.createCustomer(this.customerModel).subscribe(res => {
      debugger;
      console.log(res);
      this.router.navigate(['index']);
    }
    );
  }

  ngOnInit() {
  }

}
