import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { RegistrationDto } from '../../Dtos/registration-dto';
import { LoginDto } from '../../Dtos/login-dto';
import { HttpService } from './http.service';

@Injectable()
export class AccountService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/account';
  
  public async Register(registrationDto: RegistrationDto) {

    console.log(`registrate ${registrationDto.login}, password = ${registrationDto.password}, name = ${registrationDto.name}`);

    const response = await this.Post(`${this.url}/registrate`, registrationDto);

    if (response.statusCode != this.okStatusCode) {
      alert(this.errorMsg);
    }
  }

  public async Login(loginDto: LoginDto) {
    console.log(`login ${loginDto.login}, password = ${loginDto.password}`);

    const response = await this.Post(`${this.url}/login`, loginDto);

    if (response.statusCode != this.okStatusCode) {
      alert(this.errorMsg);
      return false;
    }
    else
      return true;
  }
}