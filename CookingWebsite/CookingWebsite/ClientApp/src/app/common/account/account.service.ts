import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';

import { RegistrationDto } from './registration-dto';
import { LoginDto } from './login-dto';
import { HttpService } from '../services/http.service';
import { AuthorizedUserDto } from "./authorized-user-dto";

@Injectable()
export class AccountService extends HttpService {

  constructor(private router: Router, http: HttpClient) {
    super(http);
  }

  private url = 'api/account';
  
  public async register(registrationDto: RegistrationDto) {

    console.log(`registrate ${registrationDto.login}, password = ${registrationDto.password}, name = ${registrationDto.name}`);

    const response: boolean = await this.Post(`${this.url}/registrate`, registrationDto);

    return response;
  }

  public async login(loginDto: LoginDto) {
    console.log(`login ${loginDto.login}, password = ${loginDto.password}`);

    const response: boolean = await this.Post(`${this.url}/login`, loginDto);

    if (!response) {
      return false;
    }
    else
      return true;
  }

  public async logout() {
    const response: boolean = await this.Get(`${this.url}/logout`);

    if (!response) {
      return false;
    }
    else
      return true;
  }

  public async getUser(){
    const response: AuthorizedUserDto = await this.Get(`${this.url}/get-authorized-user`);

    return response;
  }
}
