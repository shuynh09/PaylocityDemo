import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  loading = false;
  quote: any;
  dependents;
  httpOptions;
  errorMessage;
  successMessage;
  form: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) {
    this.dependents = new FormArray([]);
    this.form = formBuilder.group({ fullName: '', dependents: this.dependents });
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'X-Api-Key': 'XafBJrjVnSVbWqKVZ6C5'
      })
    };
  }
  public addDependent() {
    this.dependents.push(new FormControl());
  }

  public removeDependent(index) {
    this.dependents.removeAt(index);
  }

  public calculate() {
    if (!this.form.valid) {
      return;
    }

    this.loading = true;
    const payload = Object.assign({}, this.form.value);
    this.http.post(this.baseUrl + 'api/' + 'quote', payload, this.httpOptions)
      .subscribe(
        (data: any) => {
          console.log(data);
          this.loading = false;
          this.quote = data;
        },
        (error: any) => {
          this.errorMessage = 'There was an error!';
          this.loading = false;
        });
  }

  onKey(event: any) { // without type info
    this.errorMessage = '';
    this.successMessage = '';
  }

  onSubmit() {
    const payload = Object.assign({}, this.form.value);
    this.http.post(this.baseUrl + 'api/' + 'employee', payload, this.httpOptions)
      .subscribe(
        (response: any) => {
          this.quote = null;
          this.dependents.clear();
          this.form.reset();
          this.successMessage = 'Employee benefits has been submitted';
        },
        (error: any) => {
          this.errorMessage = 'There was an error!';
          this.loading = false;
        });
  }
}
