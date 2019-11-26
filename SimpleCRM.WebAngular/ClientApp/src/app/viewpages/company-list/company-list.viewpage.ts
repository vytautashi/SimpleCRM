import { Component } from '@angular/core';
import { CompanyDto } from 'src/app/interfaces/CompanyDto';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-company-list-viewpage',
  templateUrl: './company-list.viewpage.html',
})
export class CompanyListViewpage {
  public companies: CompanyDto;

  constructor(private service: CompanyService) {
    service.getCompanies().subscribe(result => {
      this.companies = result;
    }, error => console.error(error));
  }
}
