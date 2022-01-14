import { Component, Input } from '@angular/core';
import { UserMetricDto } from '../user-metric-dto';

@Component({
  selector: 'app-user-info-metric',
  templateUrl: './user-info-metric.component.html',
  styleUrls: ['./user-info-metric.component.css']
})
export class UserInfoMetricComponent {
  constructor(
  ) {

  }

  @Input() userMetric: UserMetricDto;
}
