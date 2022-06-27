import React from "react";
import Wrapper from '../../components/layout/defaultLayout/wrapper/Wrapper';

const clubs =
    [
        {
            id: 0,
            name: 'Câu Lạc Bộ Tổ Chức Sự Kiện : FEV - FPT Event Club',
            image: '../assets/images/fev.jpg',
            category: 'mains',
            linkfb: 'https://www.facebook.com/FPTEventClub/'
        },

        {
            id: 1,
            name: 'Câu Lạc Bộ Học Thuật (Lập Trình) : F-Code',
            image: '../assets/images/fcode.jpg',
            category: 'mains',
            linkfb: 'https://www.facebook.com/fcodefpt/'
        },

        {
            id: 2,
            name: 'Câu Lạc Bộ Tổ Chức Sự Kiện : FEV - FPT Event Club',
            image: '../assets/images/fev.jpg',
            category: 'mains',
            linkfb: 'https://www.facebook.com/FPTEventClub/'
        },
        {
            id: 3,
            name: 'Câu Lạc Bộ Truyền thông : Cóc Sài Gòn',
            image: '../assets/images/cocsaigon.jpg',
            category: 'mains',
            linkfb: 'https://www.facebook.com/cocsaigonfuhcm/'
        },
        {
            id: 4,
            name: 'Câu Lạc Bộ Tình Nguyện : Cộng Đồng Sinh viên tình nguyện SitiGroup',
            image: '../assets/images/sitigroup.jpg',
            category: 'mains',
            linkfb: 'https://www.facebook.com/sitigroupfuhcm'
        },
        {
            id: 5,
            name: 'Câu Lạc Bộ Tổ Chức Sự Kiện : FEV - FPT Event Club',
            image: '../assets/images/fev.jpg',
            category: 'mains',
            linkfb: 'https://www.facebook.com/FPTEventClub/'
        },
    ];


const Aboutus = () => {
    return (
        <Wrapper className="container p-[50px]">
            <div className=" flex flex-col">
                {clubs.map((club, index) => (
                    <div key={index} className="row">
                        <div className="max-w-[150px]">
                            <img src={club.image} alt={club.name} />
                        </div>
                        <div className="text-[#f24405] text-[1em] ">
                            <h5>{club.name}</h5>
                            <a href={club.linkfb}>{club.linkfb}</a>
                        </div>
                    </div>
                ))}             
            </div>
        </Wrapper>
    )
}

export default Aboutus;