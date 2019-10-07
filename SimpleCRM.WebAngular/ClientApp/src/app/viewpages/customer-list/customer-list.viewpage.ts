import { Component } from '@angular/core';
import { CustomerDto } from 'src/app/interfaces/CustomerDto';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'customer-list-viewpage',
  templateUrl: './customer-list.viewpage.html',
})
export class CustomerListViewpage {
  public customers: CustomerDto[];

  constructor(private service: CustomerService) {
    service.getCustomers().subscribe(result => {
      this.customers = result.customers;
    }, error => console.error(error));
  }
  formatDate(dateTime: Date) {
    let date: Date = new Date(dateTime);  
    let day = date.getDate();
    let monthIndex = date.getMonth();
    let year = date.getFullYear();
    let formattedDate = year + "-" + (monthIndex + 1) + "-" + day;

    return formattedDate;
  }
}
