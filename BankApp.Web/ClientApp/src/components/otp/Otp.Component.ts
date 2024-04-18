//import { Component } from '@angular/core';
//import { Identity } from '../identity//Identity.Component'; 

//@Component({
//  selector: 'app-otp',
//  templateUrl: './otp.component.html',
//  styleUrls: ['./otp.component.css']
//})
//export class OtpComponent {
//  remaining: number = 0;
//  otp: string = '';
//  showCountdown: boolean = false;
//  identity: Identity | null = null;
//  seconds: number = 0;
//  secondsFormatted: string = '';
//  countdownStep: number = 1000;

//  constructor() { }

//  setSecondsWithFormat(inputSeconds: number): void {
//    this.seconds = inputSeconds - 1;
//    this.secondsFormatted = ` - ${inputSeconds - 1} - `;
//  }

//  fetchDataForCountDown(inputIdentity: Identity): void {
//  }

//  getOtp(identity: Identity): void {
//    this.identity = identity;

//    if (identity && identity.userId && (identity.useNow || identity.dateTime)) {
//      this.fetchDataForCountDown(identity);
//    }
//  }

//  refreshOTP(): void {
//    let newIdentity: Identity | null = null;

//    if (this.identity && !this.identity.useNow) {
//      newIdentity = { ...this.identity };
//      newIdentity.dateTime = moment
//        .utc(this.identity.dateTime)
//        .add(30, "seconds")
//        .toISOString();
//      this.identity = newIdentity;
//    }

//    this.getOtp(newIdentity || this.identity);
//  }

//  ngOnInit(): void {
//    const intervalId = setInterval(() => {
//      if (this.identity && this.identity.userId && this.otp) {
//        this.setSecondsWithFormat(this.seconds);
//      }
//    }, this.countdownStep);

//    return () => clearInterval(intervalId);
//  }
//}
