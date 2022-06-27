import React, { useState } from 'react';
import emailjs from '@emailjs/browser';
import '../../App.scss';

const Result = () => {
  return (
    alert('Lời nhắn của bạn đã được gửi đi thành công. Chúng tôi sẽ liên lạc với bạn sau.')
  )
}

const Contact = () => {
  // const form = useRef();
  const [result, showResult] = useState(false);

  const sendEmail = (e) => {
    e.preventDefault();

    emailjs
      .sendForm('essgmail', 'template_ess', e.target, 'qgWIwkNalDiLxrVfi')
      .then((result) => {
        console.log(result.text);
      }, (error) => {
        console.log(error.text);
      });
    e.target.reset();
    showResult(true);
  };

  return (
    <>
      <form className='Contact max-w-[700px]' method='post' onSubmit={sendEmail}>
        <div className='form-row' >
        <label className="form-label">Họ và tên</label>
        <input className='form-input' type="text" name="user_name" required />
        </div>
        <div className='form-row' >
        <label className="form-label">Email</label>
        <input className="form-input" type="email" name="user_email" required />
        </div>
        <div className='form-row' >
        <label className="form-label">Số điện thoại</label>
        <input className="form-input" type="tel" name="user_phone" required />
        </div>
        <div className='form-row' >
        <label className='form-label'>Lời nhắn</label>
        <textarea className='form-input h-[150px]' name="message" required />
        </div>
        <div className='form-row' >
        <button className='form-submit'>Gửi</button>
        </div>
        
        {result ? <Result /> : null}
      </form>
    </>
  );
};

export default Contact;