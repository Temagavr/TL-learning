import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

export interface Response<R> {
  result: R;
  statusCode: number;
}

@Injectable()
export class HttpService {

  constructor(private http: HttpClient) { }

  public okStatusCode = 200;
  public errorMsg = 'Ooops, something went wrong, please try later again!';

  protected async Post<HttpRequest, HttpResponse>(url: string, body: HttpRequest) {

    const result = { result: null } as Response<HttpResponse>;

    try {
      const response = await this.http.post<HttpResponse>(url, body).toPromise();
      result.statusCode = this.okStatusCode;
      result.result = response;

    } catch (error) {
      alert(this.errorMsg);
      return null;
    }

    return result.result;
  }

  protected async Get<HttpR>(url: string) {

    try {
      return await this.http.get<HttpR>(url).toPromise();

    } catch (error) {
      alert(this.errorMsg);
      return null;
    }
  }
}
