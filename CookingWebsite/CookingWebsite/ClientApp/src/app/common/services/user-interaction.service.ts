import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable()
export class UserInteractionService {

  private openLoginModalSource = new Subject();

  private openRegistrationModalSource = new Subject();

  private openGreetingModalSource = new Subject();

  onOpenLoginModalRequest$ = this.openLoginModalSource.asObservable();

  onOpenRegistrationModalRequest$ = this.openRegistrationModalSource.asObservable();

  onOpenGreetingModalRequest$ = this.openGreetingModalSource.asObservable();

  showLoginModal() {
    this.openLoginModalSource.next();
  }

  showRegistrationModal() {
    this.openRegistrationModalSource.next();
  }

  showGreetingModal() {
    this.openGreetingModalSource.next();
  }
}
