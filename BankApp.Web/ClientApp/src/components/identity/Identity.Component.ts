//import { Component } from '@angular/core';
//import * as moment from 'moment';

//@Component({
//  selector: 'app-identity',
//  templateUrl: './identity.component.html',
//  styleUrls: ['./identity.component.css']
//})
//export class IdentityComponent {
//  userId: string = '';
//  useNow: boolean = true;
//  dateTime: string = moment().format('YYYY-MM-DD[T]HH:mm:ss');

//  constructor() { }

//  getUtcDateTime(): string | null {
//    if (!this.useNow) {
//      const utc = moment.utc(this.dateTime);
//      if (!utc.isValid()) {
//        alert('Input date time is invalid!');
//        return null;
//      }
//      return utc.format();
//    }
//    return null;
//  }

//  onFormSubmit(): void {
//    const utcDateTime = this.getUtcDateTime();
//    if (this.userId && (this.useNow || utcDateTime)) {
//      const payload = {
//        userId: this.userId,
//        useNow: this.useNow,
//        dateTime: utcDateTime,
//      };
//      console.log(payload); // Send this payload to your service or handle it as needed
//    }
//  }
//}
