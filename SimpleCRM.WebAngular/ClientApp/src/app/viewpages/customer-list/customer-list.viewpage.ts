import { Component } from '@angular/core';
import { CustomerDto } from 'src/app/interfaces/CustomerDto';
import { CustomerService } from 'src/app/services/customer.service';
import { CommonHelper } from 'src/app/helpers/CommonHelper';

@Component({
  selector: 'customer-list-viewpage',
  templateUrl: './customer-list.viewpage.html',
})
export class CustomerListViewpage {
  public customers: CustomerDto[];

  constructor(private service: CustomerService) {
    service.getCustomers().subscribe(result => {
      this.customers = result;
    }, error => console.error(error));
  }
  formatDate(dateTime: Date) {
    return CommonHelper.formatMyDate(dateTime);
  }
}
