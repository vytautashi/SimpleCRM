import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { CompanyService } from 'src/app/services/company.service';
import { CompanyInfoDto } from 'src/app/interfaces/CompanyInfoDto';
import { CompanyDto } from 'src/app/interfaces/CompanyDto';

@Component({
  selector: 'app-company-add-viewpage',
  templateUrl: './company-add.viewpage.html',
})
export class CompanyAddViewpage {
  public companiesInfo: CompanyInfoDto[];
  public company: CompanyInfoDto = {companyCode: "", name: "", website: "", detailsUrl: "", shortInfo: "", address: "", ceoname: "", phone : "",};
  public addForm: boolean = true;
  public msgId: number = -1;
  
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
    if (this.company.name != "") {
      this.service.getCompaniesExternalByTitle(this.company.name).subscribe(result => {
        this.companiesInfo = result.companiesInfo;
      }, error => console.error(error));
    }
  }

  public clickSubmit() {
    this.addCompany(this.service.addNewCompany({ "company": this.company }));
  }

  private addCompany(observable: Observable<any>) {
    observable.subscribe(result => {
      this.msgId = 1;
      this.addForm = false;
    }
      , error => {
        console.error(error);
        this.msgId = 0;
        this.addForm = true;
      });
  }


  public fillForm(index: number) {
    this.company = Object.assign({}, this.companiesInfo[index]);
  }

  public getDetails(index: number) {
    let url: string = encodeURIComponent(this.companiesInfo[index].detailsUrl);

    this.service.getCompanyExternalDetails(url).subscribe(result => {
      this.companiesInfo[index].companyCode = result.companyInfo.companyCode;
      this.companiesInfo[index].ceoname = result.companyInfo.ceoname;
      this.companiesInfo[index].website = result.companyInfo.website;
    }, error => console.error(error));
  }

}
