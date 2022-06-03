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
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: InitComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'nirdeshak', component: NirdeshakComponent},
      { path: 'nirikshak', component: NirikshakComponent},
      { path: 'sanchalak', component: SanchalakComponent},
      { path: 'sampark', component: SamparkKaryakarComponent}
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }