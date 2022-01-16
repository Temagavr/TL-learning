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
  
  public async register(registrationDto: RegistrationDto): Promise<boolean> {
    return await this.Post(`${this.url}/registrate`, registrationDto);
  }

  public async login(loginDto: LoginDto): Promise<boolean> {
    return await this.Post(`${this.url}/login`, loginDto);
  }

  public async logout(): Promise<boolean>  {
    return await this.Get(`${this.url}/logout`);
  }

  public async getUser(): Promise<AuthorizedUserDto> {
    const response: AuthorizedUserDto = await this.Get(`${this.url}/authorized-user`);

    return response;
  }
}
