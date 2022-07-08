import { atom } from 'recoil'

const authAtom = atom({
    key: 'authAtom',
    default: { token: null, userId: '', email: '', name: '', role: '', exp: 0 },
})

export default authAtom