import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable()
export class CompanyService {
  private url = 'api/company';


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getCompanies() {
    return this.http.get<any>(this.baseUrl + this.url);
  }

  getCompany(id: string) {
    return this.http.get<any>(this.baseUrl + this.url + "/" + id);
  }

  deleteCompany(id: number) {
    this.http.delete<any>(this.baseUrl + this.url + '/' + id, httpOptions)
      .subscribe(result => { });
  }

  addNewCompany(company) {
    return this.http.post<any>(this.baseUrl + this.url, JSON.stringify(company), httpOptions);
  }



  // Get company data from external resource

  getCompaniesExternalByCode(companyCode: string) {
    return this.http.get<any>(this.baseUrl + this.url + "/getCompaniesExternalByCode/" + companyCode);
  }

  getCompaniesExternalByTitle(title: string) {
    return this.http.get<any>(this.baseUrl + this.url + "/getCompaniesExternalByTitle/" + title);
  }

  getCompanyExternalDetails(url: string) {
    return this.http.get<any>(this.baseUrl + this.url + "/getCompanyExternalDetails/" + url);
  }
}
