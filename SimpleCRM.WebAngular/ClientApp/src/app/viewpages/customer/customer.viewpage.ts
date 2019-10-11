import { Component } from '@angular/core';
import { CustomerDto } from 'src/app/interfaces/CustomerDto';
import { CustomerService } from 'src/app/services/customer.service';
import { ActivatedRoute } from '@angular/router';

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

  // TODO move to common formaters class
  formatDate(dateTime: Date) {
    let date: Date = new Date(dateTime);
    let day = date.getDate();
    let monthIndex = date.getMonth();
    let year = date.getFullYear();
    let formattedDate = year + "-" + (monthIndex + 1) + "-" + day;

    return formattedDate;
  }
}
