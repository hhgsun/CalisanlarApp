import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [
  {
    path: "list",
    component: ListComponent
  },
  {
    path: "edit/:id",
    component: EditComponent
  },
  {
    path: "add",
    component: EditComponent
  },
  { path: '**', redirectTo: '/list', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
