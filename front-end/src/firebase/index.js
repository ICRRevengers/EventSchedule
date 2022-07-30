import { initializeApp } from "firebase/app";
import { getStorage } from "firebase/storage";

const firebaseConfig = {
  apiKey: "AIzaSyDF9Ha5DSHXEebtG0rSweF3jzDRKVsm9Ek",
  authDomain: "event-schedule-system-4284a.firebaseapp.com",
  projectId: "event-schedule-system-4284a",
  storageBucket: "event-schedule-system-4284a.appspot.com",
  messagingSenderId: "921702304775",
  appId: "1:921702304775:web:62a9454361cf01e7702ea2",
  measurementId: "G-BPHJD32G03"
};

// Initialize Firebase
export const app = initializeApp(firebaseConfig);
export const storage = getStorage(app);