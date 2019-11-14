import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class CompanyService {
  private url = 'api/company';


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getCompaniesExternalByCode(companyCode: string) {
    return this.http.get<any>(this.baseUrl + this.url + "/getCompaniesExternalByCode/" + companyCode);
  }

  getCompaniesExternalByTitle(title: string) {
    return this.http.get<any>(this.baseUrl + this.url + "/getCompaniesExternalByTitle/" + title);
  }

  getCompanyExternalDetails(url: string) {
    return this.http.get<any>(this.baseUrl + this.url + "/getCompanyExternalDetails/" + url);
  }

  getCompanies() {
    return this.http.get<any>(this.baseUrl + this.url);
  }
}
