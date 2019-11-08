import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { CompanyService } from 'src/app/services/company.service';
import { CompanyInfoDto } from 'src/app/interfaces/CompanyInfoDto';

@Component({
  selector: 'app-company-add-viewpage',
  templateUrl: './company-add.viewpage.html',
})
export class CompanyAddViewpage {
  public companiesInfo: CompanyInfoDto[];
  public company = { "companyCode": "", "title": "" };
  public addForm: boolean = true;
  
  constructor(private service: CompanyService) {
  }

  public clickFindByCode() {
    if (this.company.companyCode != "") {
      this.service.getCompaniesExternalByCode(this.company.companyCode).subscribe(result => {
        this.companiesInfo = result.companiesInfo;
      }, error => console.error(error));
    }
  }

  public clickFindByTitle() {
    if (this.company.title != "") {
      this.service.getCompaniesExternalByTitle(this.company.title).subscribe(result => {
        this.companiesInfo = result.companiesInfo;
      }, error => console.error(error));
    }
  }

  public clickSubmit() {
    alert("TODO submit");
  }

  public fillForm(index: number) {
    this.company = Object.assign({}, this.companiesInfo[index]);
  }

}
