import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DemocsrfComponent } from './components/democsrf/democsrf.component';

const routes: Routes = [
  { path: '', component: DemocsrfComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
