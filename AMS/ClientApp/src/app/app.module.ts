import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
//import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { ApiAuthorizationModule } from '../api-authorization/api-authorization.module';
//import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeGuard } from '../api-authorization/authorize.guard';
//import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { AuthorizeInterceptor } from '../api-authorization/authorize.interceptor';
// import { LoginComponent } from './Components/login/login.component';
// import { StartComponent } from './Components/start/start.component';
import { InitComponent } from './Components/init/init.component';
import { NirdeshakComponent } from './Components/nirdeshak/nirdeshak.component';
import { NirikshakComponent } from './Components/nirikshak/nirikshak.component';
import { SanchalakComponent } from './Components/sanchalak/sanchalak.component';
import { SamparkKaryakarComponent } from './Components/sampark-karyakar/sampark-karyakar.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { ListOfYuvakComponent } from './Components/list-of-yuvak/list-of-yuvak.component';

import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { AttendanceComponent } from './Components/attendance/attendance.component';
import { YuvakProfileComponent } from './Components/yuvak-profile/yuvak-profile.component';
import { EditSamparkaryakarComponent } from './Components/edit-samparkaryakar/edit-samparkaryakar.component';
import { ListOfMandalPeopleComponent } from './Components/list-of-mandal-people/list-of-mandal-people.component';
import { ProfileComponent } from './Components/profile/profile.component';
import { ListOfMandalComponent } from './Components/list-of-mandal/list-of-mandal.component';
import { SigninWithGoogleComponent } from './Components/signin-with-google/signin-with-google.component';
import { NewPasswordComponent } from './Components/new-password/new-password.component';
import { MandalSummaryComponent } from './Components/mandal-summary/mandal-summary.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    // LoginComponent,
    // StartComponent,
    InitComponent,
    NirdeshakComponent,
    NirikshakComponent,
    SanchalakComponent,
    SamparkKaryakarComponent,
    NavbarComponent,
    ListOfYuvakComponent,
    AttendanceComponent,
    YuvakProfileComponent,
    ListOfMandalPeopleComponent,
    ListOfMandalComponent,
    EditSamparkaryakarComponent,
    SigninWithGoogleComponent,
    NewPasswordComponent,
    MandalSummaryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    Ng2SearchPipeModule,
    RouterModule.forRoot([
      { path: '', component: NewPasswordComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      {
        path: 'nirdeshak', component: NirdeshakComponent, data: {
          nirdeshak: {
            id: 0,
            address: '',
            dob: '',
            education: '',
            email: '',
            karayakarNo: 0,
            kshetraId: 0,
            mobileNo: '',
            name: '',
            password: '',
            roleId: 1,
            isActivated: true
          }, isSingIn: false
        }
      },
      {
        path: 'nirikshak', component: NirikshakComponent, data: {
          nirikshak: {
            id: 0,
            address: '',
            dob: '',
            education: '',
            email: '',
            karayakarNo: 0,
            kshetraId: 0,
            mobileNo: '',
            name: '',
            password: '',
            roleId: 1,
            isActivated: true
          }, isSingIn: false
        }
      },
      {
        path: 'sanchalak', component: SanchalakComponent, data: {
          sanchalak: {
            id: 0,
            address: '',
            dob: '',
            education: '',
            email: '',
            karayakarNo: 0,
            kshetraId: 0,
            mobileNo: '',
            name: '',
            password: '',
            roleId: 1,
            isActivated: true
          }, isSingIn: false
        }
      },
      {
        path: 'sampark', component: SamparkKaryakarComponent, data: {
          samparkKaryakar: {
            id: 0,
            address: '',
            dob: '',
            education: '',
            email: '',
            karayakarNo: 0,
            kshetraId: 0,
            mobileNo: '',
            name: '',
            password: '',
            roleId: 1,
            isActivated: true
          }, isSingIn: false
        }
      },
      { path: 'yuvakList', component: ListOfYuvakComponent, data: {mandalId: 0} },
      { path: 'yuvalProfile', component: YuvakProfileComponent },
      { path: 'editSampark', component: EditSamparkaryakarComponent },
      { path: 'listOfMandalPeople', component: ListOfMandalPeopleComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'signInWithGoogle', component: SigninWithGoogleComponent },
      { path: 'newPassword', component: NewPasswordComponent },
      { path: 'takeAttendance', component: AttendanceComponent },
      { path: 'mandalSummary', component: MandalSummaryComponent },

    ]),


  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }