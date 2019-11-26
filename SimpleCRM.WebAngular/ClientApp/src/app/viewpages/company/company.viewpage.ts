import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CompanyDto } from 'src/app/interfaces/CompanyDto';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'company-viewpage',
  templateUrl: './company.viewpage.html',
})
export class CompanyViewpage {
  public company: CompanyDto

  constructor(private service: CompanyService, route: ActivatedRoute) {
    service.getCompany(route.snapshot.paramMap.get('id')).subscribe(result => {
      this.company = result;
    }, error => console.error(error));
  }

}
