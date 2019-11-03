import { Component } from '@angular/core';
import { CustomerDto } from 'src/app/interfaces/CustomerDto';
import { CustomerService } from 'src/app/services/customer.service';
import { ActivatedRoute } from '@angular/router';
import { CommonHelper } from 'src/app/helpers/CommonHelper';

@Component({
  selector: 'customer-viewpage',
  templateUrl: './customer.viewpage.html',
})
export class CustomerViewpage {
  public customer: CustomerDto;

  constructor(private service: CustomerService, route: ActivatedRoute) {
    service.getCustomer(route.snapshot.paramMap.get('id')).subscribe(result => {
      this.customer = result.customer;
    }, error => console.error(error));
  }

  formatDate(dateTime: Date) {
    return CommonHelper.formatMyDate(dateTime);
  }
}
