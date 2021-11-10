import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable()
export class UserInteractionService {

  private openLoginModalSource = new Subject();

  onOpenLoginModalRequest$ = this.openLoginModalSource.asObservable();

  showLoginModal() {
    this.openLoginModalSource.next();
  }
}