import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatListModule} from '@angular/material/list';
import {MatTableModule} from '@angular/material/table';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatChipsModule} from '@angular/material/chips';
import { MatInputModule } from '@angular/material/input';
import {MatIcon, MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import {Component} from '@angular/core';
import {NgIf} from '@angular/common';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSnackBar, MatSnackBarRef, MatSnackBarModule} from '@angular/material/snack-bar';

const material = [
  CommonModule,
  MatToolbarModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatListModule,
  MatTableModule,
  MatSlideToggleModule,
  MatChipsModule,
  MatInputModule,
  MatIconModule,
  MatSidenavModule, NgIf, MatButtonModule,
  MatDatepickerModule,
  MatNativeDateModule,
  BrowserAnimationsModule,
  MatInputModule, MatButtonModule, MatSnackBarModule
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    material
  ],
  exports: [
    material
  ],
  // exports: material
})
export class AppModuleModule { }
