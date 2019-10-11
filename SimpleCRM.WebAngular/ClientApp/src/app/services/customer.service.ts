import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CustomerService {
  private url = 'api/customer';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getCustomers() {
    return this.http.get<any>(this.baseUrl + this.url);
  }

  getCustomer(id: string) {
    return this.http.get<any>(this.baseUrl + this.url + "/" + id);
  }

  getCustomerByPhone(phoneNumber: string) {
    return this.http.get<any>(this.baseUrl + this.url  + "/GetByPhone/" + phoneNumber);
  }
}
