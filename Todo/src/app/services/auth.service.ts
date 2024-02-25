// auth.service.ts
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  login(username: string, password: string): boolean {
    // In a real application, you would send an HTTP request to a server to authenticate the user
    // For simplicity, we'll hardcode the credentials here
    if (username === 'admin' && password === 'password') {
      // Store the username in local storage to simulate session persistence
      localStorage.setItem('username', username);
      return true;
    } else {
      return false;
    }
  }

  register(username: string, password: string): boolean {
    // In a real application, you would send an HTTP request to a server to register the user
    // For simplicity, we'll just return true here
    return true;
  }

  logout(): void {
    // Clear the username from local storage to simulate logout
    localStorage.removeItem('username');
  }

  isLoggedIn(): boolean {
    // Check if the username is present in local storage to simulate session persistence
    return !!localStorage.getItem('username');
  }
}
