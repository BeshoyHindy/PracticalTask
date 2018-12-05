import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CustomerService } from '../../services/customer.service';
import { Customer } from '../../models/Customer.Model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  angForm: FormGroup;
  customerModel: Customer;

  constructor(private customerService: CustomerService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder) {
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

    this.updateCustomer();
  }

  updateCustomer() {
    this.customerService.updateCustomer(this.customerModel).subscribe(res => {
      debugger;
      console.log(res);
      this.router.navigate(['index']);
    }
    );
  }

  ngOnInit() {
    debugger
    this.route.params.subscribe(params => {
      this.customerService.getCustomerById(params['id']).subscribe(res => {
        console.log(res);
        this.customerModel = res.data;
      });
    });
  }
}
