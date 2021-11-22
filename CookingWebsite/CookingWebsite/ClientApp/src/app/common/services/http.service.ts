import { Injectable } from "@angular/core";
import { HttpClient, HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';

export interface Response<R> {
  result: R;
  statusCode: number;
}

@Injectable()
export class HttpService {

  constructor(private http: HttpClient) { }

  protected async Post<HttpRequest, HttpResponse>(url: string, body: HttpRequest)/*: Promise<HttpResponse>*/ {

    const result = { result: null } as Response<HttpResponse>;

    try {
      const response = await this.http.post<HttpResponse>(url, body).toPromise();
      result.statusCode = 200;
      result.result = response;

    } catch (error) {
      result.statusCode = error.status;
    }

    return result;
  }

  protected async Get<HttpR>(url: string, body)/*: Promise<Response<HttpR>>*/ {

    const result = { result: null } as Response<HttpR>;

    try {
      const response = await this.http.post<HttpR>(url, body).toPromise();
      result.statusCode = 200;
      result.result = response;

    } catch (error) {
      result.statusCode = error.status;
    }

    return result;
  }
}
